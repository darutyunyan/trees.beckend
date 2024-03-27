using Trees.Core.Models;
using Trees.Core.Interfaces;
using System.Xml.Linq;

namespace Trees.Core.Services
{
    public class TreeService : ITreeService
    {
        public const int InfoItemValueCount = 4;
        public const string InfoValueSeparator = " ";

        public TreeService(
            ITreeRepository treeRepository,
            IImgService imgService,
            ILegService legService,
            IAssemblyMethodService assemblyMethodService,
            IMaterialService materialService,
            IBrandService brandService)
        {
            _treeRepository = treeRepository;
            _imgService = imgService;
            _legService = legService;
            _assemblyMethodService = assemblyMethodService;
            _materialService = materialService;
            _brandService = brandService;
        }

        public async Task CreateAsync(Tree tree)
        {
            await _ValidateTree(tree);
            await _InitComponent(tree);

            await _treeRepository.CreateAsync(tree);
        }

        public async Task UpdateAsync(Tree tree)
        {
            await _ValidateTree(tree);
            await _InitComponent(tree);

            await _treeRepository.UpdateAsync(tree);
        }

        public async Task<List<Tree>> GetAllAsync() => await _treeRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id) => await _treeRepository.DeleteAsync(id);

        private async Task _ValidateTree(Tree tree)
        {
            _ValidateInfo(tree);

            Img? img = await _imgService.GetAsync(tree.ImgId); ;

            if (img == null)
                throw new ArgumentException(nameof(Img)); // todo 

            if (tree.LegId.HasValue && (await _legService.GetAsync(tree.LegId.Value) == null))
                throw new ArgumentException(nameof(Leg)); // todo 

            if (tree.AssemblyMethodId.HasValue && (await _assemblyMethodService.GetAsync(tree.AssemblyMethodId.Value) == null))
                throw new ArgumentException(nameof(AssemblyMethod)); // todo 

            if (tree.MaterialId.HasValue && (await _materialService.GetAsync(tree.MaterialId.Value) == null))
                throw new ArgumentException(nameof(Material)); // todo 

            if (tree.BrandId.HasValue && (await _brandService.GetAsync(tree.BrandId.Value) == null))
                throw new ArgumentException(nameof(Brand)); // todo 
        }

        private void _ValidateInfo(Tree tree)
        {
            if (tree.Info == null || tree.Info.Length == 0)
                throw new ArgumentException(nameof(tree.Info)); // todo

            foreach (var value in tree.Info)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(value)); // todo

                string[] items = value.Split(InfoValueSeparator);

                if (items.Length != InfoItemValueCount)
                    throw new ArgumentException(nameof(value)); // todo
            }
        }

        private async Task _InitComponent(Tree tree)
        {
            tree.InfoXml = _ConvertInfoToXml(tree.Info);
            //tree.Img = await _imgRepository.GetAsync(tree.ImgId) ?? throw new ArgumentException(nameof(Img));
            //tree.Leg = tree.LegId.HasValue ? await _legRepository.GetAsync(tree.LegId.Value) : null;
            // tree.AssemblyMethod = tree.AssemblyMethodId.HasValue ? await _assemblyMethodRepository.GetAsync(tree.AssemblyMethodId.Value) : null;
            //tree.Material = tree.MaterialId.HasValue ? await _materialRepository.GetAsync(tree.MaterialId.Value) : null;
            //tree.Brand = tree.BrandId.HasValue ? await _brandRepository.GetAsync(tree.BrandId.Value) : null;
        }

        private string _ConvertInfoToXml(string[] info)
        {
            XElement itemsXmlElement = new(ITEMS_XML_ELEMENT);

            foreach (var value in info)
            {
                string[] items = value.Split(InfoValueSeparator);

                XElement itemXmlElement = new XElement(ITEM_XML_ELEMENT);

                itemXmlElement.Add(new XElement(HEIGHT_XML_ELEMENT, items[HEIGHT_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(DIAMETER_XML_ELEMENT, items[DIAMETER_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(TIPS_XML_ELEMENT, items[TIPS_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(PRICE_XML_ELEMENT, items[PRICE_XML_ELEMENT_INDEX]));

                itemsXmlElement.Add(itemXmlElement);
            }

            return XElement.Parse(itemsXmlElement.ToString()).ToString(SaveOptions.DisableFormatting);
        }

        private const string ITEMS_XML_ELEMENT = "items";
        private const string ITEM_XML_ELEMENT = "item";
        private const string HEIGHT_XML_ELEMENT = "height";
        private const string DIAMETER_XML_ELEMENT = "diameter";
        private const string TIPS_XML_ELEMENT = "tips";
        private const string PRICE_XML_ELEMENT = "price";

        private const int HEIGHT_XML_ELEMENT_INDEX = 0;
        private const int DIAMETER_XML_ELEMENT_INDEX = 1;
        private const int TIPS_XML_ELEMENT_INDEX = 2;
        private const int PRICE_XML_ELEMENT_INDEX = 3;

        private readonly ITreeRepository _treeRepository;
        private readonly IImgService _imgService;
        private readonly ILegService _legService;
        private readonly IAssemblyMethodService _assemblyMethodService;
        private readonly IMaterialService _materialService;
        private readonly IBrandService _brandService;
    }
}
